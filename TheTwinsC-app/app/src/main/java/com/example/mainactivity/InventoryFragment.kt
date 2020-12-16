package com.example.mainactivity

import android.content.Intent
import android.os.Bundle
import android.os.PersistableBundle
import android.view.LayoutInflater
import androidx.fragment.app.Fragment
import android.view.View
import android.view.ViewGroup
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class InventoryFragment : Fragment(R.layout.fragment_inventory) {

    val oreAmount= 2
    val ingotAmount = 0
    val coinAmount = 0

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        var invList = mutableListOf(
            Items("Ore x$oreAmount", "Ores are gathered every hour inside the mine", R.drawable.ic_gold_ingot),
            Items("Ingot x$ingotAmount", "Ingots are forged in the anvil, it can be traded in the shop or sent to the player", R.drawable.ic_ingot),
            Items("Coin x$coinAmount", "Coins are the currency trading of this game and can be sent to the player or used to buy upgrades", R.drawable.ic_money)
        )

        val invRecycler = view.findViewById<RecyclerView>(R.id.invRecycler)
        invRecycler.adapter = InvAdapter(invList)
        invRecycler.layoutManager = LinearLayoutManager(this.activity)


    }
}