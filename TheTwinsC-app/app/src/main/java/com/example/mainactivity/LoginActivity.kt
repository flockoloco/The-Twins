package com.example.mainactivity

import android.content.Intent
import android.os.Bundle
import android.text.TextUtils
import android.util.Log
import android.view.LayoutInflater
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import com.beust.klaxon.Json
import com.beust.klaxon.JsonObject
import com.beust.klaxon.JsonReader
import com.beust.klaxon.Klaxon
import com.example.mainactivity.retrofit.INodeJS
import com.example.mainactivity.retrofit.RetrofitClient
import com.google.gson.Gson
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.disposables.CompositeDisposable
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.activity_login.*
import kotlinx.android.synthetic.main.confirmpassword_box.view.*
import org.json.JSONStringer
import retrofit2.Retrofit
import java.io.Serializable
import java.io.StringReader
import kotlin.reflect.jvm.internal.impl.load.kotlin.JvmType

class LoginActivity : AppCompatActivity() {

    lateinit var myAPI: INodeJS
    var compositeDisposable = CompositeDisposable()
    private lateinit var msgDialog:AlertDialog

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        msgDialog = AlertDialog.Builder(this)
            .setIcon(R.drawable.ic_error)
            .setTitle("Error")
            .setMessage("Wrong Username or Password, please try again!")
            .setNeutralButton("Ok") { _, _ -> }
            .create()

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

        compositeDisposable.add(myAPI.loginUser(Username, Password)
            .subscribeOn(Schedulers.io())
            .observeOn(AndroidSchedulers.mainThread())
            .subscribe { message ->
                if (message.contains("UserPassword")) {
                    Intent(this, MainActivity::class.java).also {
                        val result = Klaxon().parse<UserClass>(message)
                        if (result != null) {
                            User.UserID = result.UserID
                            User.UserName = result.UserName
                        }
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
                                    .subscribe { _ ->
                                        Toast.makeText(this, "successfully register", Toast.LENGTH_SHORT).show()
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