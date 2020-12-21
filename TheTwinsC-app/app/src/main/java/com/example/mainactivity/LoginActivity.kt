package com.example.mainactivity

import android.content.Intent
import android.os.Bundle
import android.text.TextUtils
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import com.example.mainactivity.retrofit.INodeJS
import com.example.mainactivity.retrofit.RetrofitClient
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.disposables.CompositeDisposable
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.activity_login.*
import retrofit2.Retrofit

class LoginActivity : AppCompatActivity() {

    lateinit var myAPI: INodeJS
    var compositeDisposable = CompositeDisposable()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        //iniciar API
        val retrofit: Retrofit = RetrofitClient.instance
        myAPI = retrofit.create(INodeJS::class.java)

        btnLogin.setOnClickListener {
            val username = lgnUsername.text.toString()
            val password = lgnPassword.text.toString()
            if (!checkBox()) {
                login(username, password)
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