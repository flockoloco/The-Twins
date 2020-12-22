package com.example.mainactivity

import android.content.Intent
import android.os.Bundle
import android.text.TextUtils
import android.view.LayoutInflater
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import com.example.mainactivity.retrofit.INodeJS
import com.example.mainactivity.retrofit.RetrofitClient
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.disposables.CompositeDisposable
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.activity_login.*
import kotlinx.android.synthetic.main.confirmpassword_box.view.*
import retrofit2.Retrofit

class LoginActivity : AppCompatActivity() {

    lateinit var myAPI: INodeJS
    var compositeDisposable = CompositeDisposable()
    private lateinit var msgDialog1:AlertDialog

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        msgDialog1 = AlertDialog.Builder(this).setIcon(R.drawable.ic_error).setTitle("Error").setMessage("Wrong Username or Password, please try again!").setNeutralButton("Ok") { _, _ -> }.create()

        //iniciar API
        val retrofit: Retrofit = RetrofitClient.instance
        myAPI = retrofit.create(INodeJS::class.java)

        btnLogin.setOnClickListener {
            val username = lgnUsername.text.toString()
            val password = lgnPassword.text.toString()
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
    }

    private fun login(Username: String, Password: String) {

        val error = AlertDialog.Builder(this)
            .setTitle("Error")
            .setMessage("Wrong Username or Password, please try again!")
            .setNeutralButton("Ok") { _, _ -> }
            .create()

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
                    msgDialog1.show()
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
                    msgDialog1.setMessage("Username already registered, please try a different username !")
                    msgDialog1.show()
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
                                msgDialog1.setMessage("Password does not match, please try again! ")
                                msgDialog1.show()
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