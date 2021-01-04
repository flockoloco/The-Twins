package com.example.mainactivity

import android.os.Bundle
import android.view.Menu
import android.view.MenuItem
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import com.example.mainactivity.retrofit.INodeJS
import com.example.mainactivity.retrofit.RetrofitClient
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.disposables.CompositeDisposable
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.drawer_header.view.*
import retrofit2.Retrofit


class MainActivity : AppCompatActivity() {

    lateinit var toggle: ActionBarDrawerToggle
    lateinit var myAPI: INodeJS
    var compositeDisposable = CompositeDisposable()

    private lateinit var msgDialog: AlertDialog

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //iniciar API
        val retrofit: Retrofit = RetrofitClient.instance
        myAPI = retrofit.create(INodeJS::class.java)

        msgDialog = AlertDialog.Builder(this)
            .setIcon(R.drawable.ic_heart)
            .setNeutralButton("Ok") { _, _ -> }
            .create()

        //Bottom navigation
        val anvilFragment = AnvilFragment()
        val mineFragment = MineFragment()

        setCurrentFragment(anvilFragment)

        bottom_navigation.setOnNavigationItemSelectedListener {
            when (it.itemId) {
                R.id.AnvilFragment -> setCurrentFragment(anvilFragment)
                R.id.MineFragment -> setCurrentFragment(mineFragment)
            }
            true
        }
        bottom_navigation.getOrCreateBadge(R.id.AnvilFragment).apply {
            number = Resources.Nuggets
            isVisible = true
        }
        //-=-=-=-=-=-=-=-=-=-=--=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=-==-=-=-=

        //Top navigation
        val shopFragment = ShopFragment()
        val inventoryFragment = InventoryFragment()

        toggle = ActionBarDrawerToggle(this, drawerLayout, R.string.open, R.string.close)
        drawerLayout.addDrawerListener(toggle)
        toggle.syncState()

        supportActionBar?.setDisplayHomeAsUpEnabled(true)

        val message = "Hi ${User.UserName}, welcome back"
        navigation_view.getHeaderView(0).txtmessage.text = message


        navigation_view.setNavigationItemSelectedListener {

            when (it.itemId) {
                R.id.ShopFragment -> setCurrentFragment(shopFragment)
                R.id.InventoryFragment -> setCurrentFragment(inventoryFragment)
                R.id.Quit -> finish()
            }
            drawerLayout.closeDrawers()
            true
        }
        //-=-=-=-=-=-=-=-=-=-=--=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=-==-=-=-=

    }

    private fun setCurrentFragment(fragment: Fragment) {
        supportFragmentManager.beginTransaction().apply {
            replace(R.id.hostFragment, fragment)
            addToBackStack(null)
            commit()
        }
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.top_drawer, menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        if (toggle.onOptionsItemSelected(item)) {
            return true
        }
        return super.onOptionsItemSelected(item)
    }

    override fun onStop() {
        compositeDisposable.clear()
        onCloseActivity()
        super.onStop()
    }

    private fun onCloseActivity() {
        compositeDisposable.add(myAPI.sendDB(Resources.Gold, Resources.Nuggets, Resources.Bars, Resources.Minespd, Resources.MineHarvest, Resources.PermUpgrade, Resources.FirstTime, User.UserID)
            .subscribeOn(Schedulers.io())
            .observeOn(AndroidSchedulers.mainThread())
            .subscribe {}
        )
    }

    override fun onDestroy() {
        compositeDisposable.clear()
        super.onDestroy()
    }

}