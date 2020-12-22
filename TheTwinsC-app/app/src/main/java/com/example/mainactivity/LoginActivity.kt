package com.example.mainactivity

import android.content.Intent
import android.os.Bundle
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 5e9c894... ooh?
import android.text.TextUtils
<<<<<<< HEAD
import android.util.Log
import android.view.LayoutInflater
import android.widget.EditText
import android.widget.Toast
<<<<<<< HEAD
=======
import android.widget.EditText
>>>>>>> parent of e6ff177... commit apenas para mim se o casa abrir é gay haahaha
=======
import android.util.Log
import android.widget.Toast
>>>>>>> parent of 2080c1f... minor fix
=======
>>>>>>> parent of 0b58579... blabla mini update capp
=======
>>>>>>> parent of 5e9c894... ooh?
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
=======
>>>>>>> parent of 5e9c894... ooh?
import kotlinx.android.synthetic.main.confirmpassword_box.*
import kotlinx.android.synthetic.main.confirmpassword_box.view.*
=======
>>>>>>> parent of 0b58579... blabla mini update capp
import retrofit2.Retrofit

class LoginActivity : AppCompatActivity() {

    lateinit var myAPI: INodeJS
    var compositeDisposable = CompositeDisposable()

<<<<<<< HEAD
    private val msgDialog = AlertDialog.Builder(this)
        .setTitle("Error")
        .setMessage("Wrong Username or Password, please try again!")
        .setNeutralButton("Ok") { _, _ -> }
        .create()

<<<<<<< HEAD
=======

class LoginActivity : AppCompatActivity() {
>>>>>>> parent of e6ff177... commit apenas para mim se o casa abrir é gay haahaha
=======
>>>>>>> parent of 0b58579... blabla mini update capp
=======
>>>>>>> parent of 5e9c894... ooh?
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        //iniciar API
        val retrofit:Retrofit = RetrofitClient.instance
        myAPI = retrofit.create(INodeJS::class.java)

        btnLogin.setOnClickListener{
            val username = lgnUsername.text.toString()
            val password = lgnPassword.text.toString()
<<<<<<< HEAD
<<<<<<< HEAD
            if (!fieldsCheck()) {
=======
            if (!checkBox()) {
>>>>>>> parent of 0b58579... blabla mini update capp
                login(username, password)
            }
=======
            login(username, password)
>>>>>>> parent of 2080c1f... minor fix
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
=======

        val error = AlertDialog.Builder(this)
            .setTitle("Error")
            .setMessage("Username or Password not inserted")
            .setNeutralButton("Ok") { _, _ -> }
            .create()
>>>>>>> parent of 2080c1f... minor fix
=======

        val error = AlertDialog.Builder(this)
            .setTitle("Error")
            .setMessage("Wrong Username or Password, please try again!")
            .setNeutralButton("Ok") { _, _ -> }
            .create()
>>>>>>> parent of 0b58579... blabla mini update capp
        compositeDisposable.add(myAPI.loginUser(Username, Password)
            .subscribeOn(Schedulers.io())
            .observeOn(AndroidSchedulers.mainThread())
            .subscribe { message ->
                if (message.contains("UserPassword")) {
                    Intent(this, MainActivity::class.java).also{
                        it.putExtra("EXTRA_USERNAME", Username)
                        startActivity(it)
                    }
<<<<<<< HEAD
                } else {
                    error.show()
                }
            }
        )
    }

    private fun register(Username: String, Password: String){
        
    }

    private fun checkBox(): Boolean {
        if (TextUtils.isEmpty(lgnUsername.text.toString()) || TextUtils.isEmpty(lgnPassword.text.toString())) {
            if (TextUtils.isEmpty(lgnUsername.text.toString())) {
                lgnUsername.error = "Please insert a username!"
=======
                }else{
                error.show()
>>>>>>> parent of 2080c1f... minor fix
            }
            }
        )
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