package com.example.mainactivity.retrofit

import io.reactivex.Observable
import retrofit2.http.Field
import retrofit2.http.FormUrlEncoded
import retrofit2.http.POST

interface INodeJS {
    @POST("register")
    @FormUrlEncoded
    fun registerUser(
        @Field("Username") Username: String,
        @Field("Password") Password: String
    ): Observable<String>


    @POST("login")
    @FormUrlEncoded
    fun loginUser(
        @Field("Username") Username: String,
        @Field("Password") Password: String
    ): Observable<String>

    @POST("user")
    @FormUrlEncoded
    fun getApp(@Field("UserID") UserID: Int): Observable<String>

    @POST("sendDB")
    @FormUrlEncoded
    fun sendDB(
        @Field("Gold") Gold: Int,
        @Field("Nuggets") Nuggets: Int,
        @Field("Bars") Bars: Int,
        @Field("Minespd") Minespd: Int,
        @Field("MineHarvest") MineHarvest: Int,
        @Field("PermUpgrade") PermUpgrade: Int,
        @Field("FirstTime") FirstTime: Int,
        @Field("UserID") UserID: Int
    ): Observable<String>
}