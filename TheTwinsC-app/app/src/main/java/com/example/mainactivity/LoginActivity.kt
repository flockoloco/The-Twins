package com.example.mainactivity

import android.content.Intent
import android.os.Bundle
import android.widget.EditText
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_login.*

class LoginActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        val error = AlertDialog.Builder(this)
            .setTitle("Error")
            .setMessage("Username or Password not inserted")
            .setNeutralButton("Ok") { _, _ -> }
            .create()

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
        }
    }
}