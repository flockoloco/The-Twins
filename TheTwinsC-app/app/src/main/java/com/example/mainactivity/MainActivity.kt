package com.example.mainactivity

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.MenuItem
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.fragment.app.Fragment
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.drawer_header.*

class MainActivity : AppCompatActivity() {

    lateinit var toggle: ActionBarDrawerToggle

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //Bottom navigation
        val anvilFragment = AnvilFragment()
        val mineFragment = MineFragment()

        setCurrentFragment(anvilFragment)

        bottom_navigation.setOnNavigationItemSelectedListener {
            when(it.itemId){
                R.id.AnvilFragment -> setCurrentFragment(anvilFragment)
                R.id.MineFragment -> setCurrentFragment(mineFragment)
            }
            true
        }
        //-=-=-=-=-=-=-=-=-=-=--=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=-==-=-=-=

        //Top navigation
        val shopFragment = ShopFragment()
        val inventoryFragment = InventoryFragment()

        toggle = ActionBarDrawerToggle(this, drawerLayout, R.string.open, R.string.close)
        drawerLayout.addDrawerListener(toggle)
        toggle.syncState()

        supportActionBar?.setDisplayHomeAsUpEnabled(true)

        navigation_view.setNavigationItemSelectedListener {
            val username = intent.getStringExtra("EXTRA_USERNAME")
            val message = "Hi $username, welcome back"
            txtmessage.text = message
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

    private fun setCurrentFragment(fragment: Fragment){
        supportFragmentManager.beginTransaction().apply {
            replace(R.id.hostFragment, fragment)
            addToBackStack(null)
            commit()
        }
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        if(toggle.onOptionsItemSelected(item)){
            return true
        }
        return super.onOptionsItemSelected(item)
    }

}