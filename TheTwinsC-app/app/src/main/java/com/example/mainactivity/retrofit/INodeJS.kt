package com.example.mainactivity.retrofit

import io.reactivex.Observable
import retrofit2.http.Field
import retrofit2.http.FormUrlEncoded
import retrofit2.http.GET
import retrofit2.http.POST

interface INodeJS {
    @POST("register")
    @FormUrlEncoded
    fun registerUser(@Field("Username") Username:String, @Field("Password") Password:String):Observable<String>


    @POST("login")
    @FormUrlEncoded
    fun loginUser(@Field("Username") Username:String, @Field("Password") Password:String):Observable<String>

    /*@GET("User")
    @FormUrlEncoded
    fun getCapp(@Field())*/
}