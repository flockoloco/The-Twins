package com.example.mainactivity

import android.content.Intent
import android.os.Bundle
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 5e9c894... ooh?
=======
>>>>>>> parent of fd27792... ooh? 2
import android.text.TextUtils
import android.util.Log
import android.view.LayoutInflater
import android.widget.EditText
import android.widget.Toast
<<<<<<< HEAD
=======
import android.widget.EditText
>>>>>>> parent of e6ff177... commit apenas para mim se o casa abrir é gay haahaha
<<<<<<< HEAD
=======
import android.util.Log
import android.widget.Toast
>>>>>>> parent of 2080c1f... minor fix
<<<<<<< HEAD
=======
>>>>>>> parent of 0b58579... blabla mini update capp
=======
>>>>>>> parent of 5e9c894... ooh?
=======
>>>>>>> parent of fd27792... ooh? 2
=======
>>>>>>> parent of 32c0bea... ooh? 3
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import com.example.mainactivity.retrofit.INodeJS
import com.example.mainactivity.retrofit.RetrofitClient
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.disposables.CompositeDisposable
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.activity_login.*
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 5e9c894... ooh?
=======
>>>>>>> parent of 32c0bea... ooh? 3
import kotlinx.android.synthetic.main.confirmpassword_box.*
import kotlinx.android.synthetic.main.confirmpassword_box.view.*
import retrofit2.Retrofit

class LoginActivity : AppCompatActivity() {

    lateinit var myAPI: INodeJS
    var compositeDisposable = CompositeDisposable()

    private val msgDialog = AlertDialog.Builder(this)
        .setTitle("Error")
        .setMessage("Wrong Username or Password, please try again!")
        .setNeutralButton("Ok") { _, _ -> }
        .create()

<<<<<<< HEAD
=======

class LoginActivity : AppCompatActivity() {
>>>>>>> parent of e6ff177... commit apenas para mim se o casa abrir é gay haahaha
<<<<<<< HEAD
=======
>>>>>>> parent of 0b58579... blabla mini update capp
=======
>>>>>>> parent of 5e9c894... ooh?
=======
>>>>>>> parent of 32c0bea... ooh? 3
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        //iniciar API
        val retrofit: Retrofit = RetrofitClient.instance
        myAPI = retrofit.create(INodeJS::class.java)

        btnLogin.setOnClickListener {
            val username = lgnUsername.text.toString()
            val password = lgnPassword.text.toString()
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of fd27792... ooh? 2
=======
>>>>>>> parent of 32c0bea... ooh? 3
            if (!fieldsCheck()) {
                login(username, password)
            }
        }

        btnRegister.setOnClickListener {
            val username = lgnUsername.text.toString()
            val password = lgnPassword.text.toString()
            if (!fieldsCheck()) {
                register(username, password)
            }
        }
        /*

        btnLogin.setOnClickListener{
            val username = lgnUsername.text.toString()
            val password = lgnPassword.text.toString()
            if(username.trim().isEmpty() || password.trim().isEmpty()) {
                error.show()
            }
            else{
                Intent(this, MainActivity::class.java).also{
                    it.putExtra("EXTRA_USERNAME", username)
                    startActivity(it)
                }
            }
        }*/
    }

    private fun login(Username: String, Password: String) {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 32c0bea... ooh? 3
=======

        val error = AlertDialog.Builder(this)
            .setTitle("Error")
            .setMessage("Username or Password not inserted")
            .setNeutralButton("Ok") { _, _ -> }
            .create()
>>>>>>> parent of 2080c1f... minor fix
<<<<<<< HEAD
=======

        val error = AlertDialog.Builder(this)
            .setTitle("Error")
            .setMessage("Wrong Username or Password, please try again!")
            .setNeutralButton("Ok") { _, _ -> }
            .create()
>>>>>>> parent of 0b58579... blabla mini update capp
=======
>>>>>>> parent of fd27792... ooh? 2
=======
>>>>>>> parent of 32c0bea... ooh? 3
        compositeDisposable.add(myAPI.loginUser(Username, Password)
            .subscribeOn(Schedulers.io())
            .observeOn(AndroidSchedulers.mainThread())
            .subscribe { message ->
                if (message.contains("UserPassword")) {
                    Intent(this, MainActivity::class.java).also {
                        it.putExtra("EXTRA_USERNAME", Username)
                        startActivity(it)
                    }
                } else {
                    msgDialog.show()
                }
            }
        )
    }

    private fun register(Username: String, Password: String) {

        compositeDisposable.add(myAPI.loginUser(Username, Password)
            .subscribeOn(Schedulers.io())
            .observeOn(AndroidSchedulers.mainThread())
            .subscribe { message ->
                if (message.contains("UserName")) {
                    msgDialog.setMessage("Username already registered, please try a different username !")
                    msgDialog.show()
                } else {
                    val inflatePassword =
                        LayoutInflater.from(this).inflate(R.layout.confirmpassword_box, null)

                    AlertDialog.Builder(this)
                        .setTitle("Confirm Password")
                        .setView(inflatePassword)
                        .setNegativeButton("Cancel") { _, _ -> }
                        .setPositiveButton("Confirm") { _, _ ->
                            val confirmedPass = inflatePassword.lgnConfirmPassword as EditText
                            if (Password == confirmedPass.text.toString()) {
                                compositeDisposable.add(myAPI.registerUser(Username, Password)
                                    .subscribeOn(Schedulers.io())
                                    .observeOn(AndroidSchedulers.mainThread())
                                    .subscribe {
                                        Toast.makeText(
                                            this,
                                            "successfully register",
                                            Toast.LENGTH_SHORT
                                        ).show()
                                    }
                                )
                            } else {
                                msgDialog.setMessage("Password does not match, please try again! ")
                                msgDialog.show()
                            }
                        }.show()
                }
            }
        )
    }


    private fun fieldsCheck(): Boolean {
        if (TextUtils.isEmpty(lgnUsername.text.toString()) || TextUtils.isEmpty(lgnPassword.text.toString())) {
            if (TextUtils.isEmpty(lgnUsername.text.toString())) {
                lgnUsername.error = "Please insert a username!"
            }
            if (TextUtils.isEmpty(lgnPassword.text.toString())) {
                lgnPassword.error = "Please insert a password!"
            }
            return true
        }
        return false
    }

    override fun onStop() {
        compositeDisposable.clear()
        super.onStop()
    }

    override fun onDestroy() {
        compositeDisposable.clear()
        super.onDestroy()
    }
}