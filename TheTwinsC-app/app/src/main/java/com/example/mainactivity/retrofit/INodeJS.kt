package com.example.mainactivity.retrofit

import io.reactivex.Observable
import retrofit2.http.Field
import retrofit2.http.FormUrlEncoded
import retrofit2.http.GET
import retrofit2.http.POST
import java.util.*

interface INodeJS {
    @POST("register")
    @FormUrlEncoded
    fun registerUser(@Field("Username") Username:String, @Field("Password") Password:String):Observable<String>


    @POST("login")
    @FormUrlEncoded
    fun loginUser(@Field("Username") Username:String, @Field("Password") Password:String):Observable<String>

    @POST("user")
    @FormUrlEncoded
    fun getApp(@Field("UserID") UserID:Int):Observable<String>
}