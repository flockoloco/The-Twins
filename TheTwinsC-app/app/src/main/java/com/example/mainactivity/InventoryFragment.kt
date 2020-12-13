package com.example.mainactivity

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.View
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class InventoryFragment : Fragment(R.layout.fragment_inventory) {

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        var invList = mutableListOf(
            Items("Ore x25", "Ores are gathered every hour inside the mine", R.drawable.ic_gold_ingot),
            Items("Ingot x50", "Ingots are forged in the anvil, it can be traded in the shop or sent to the player", R.drawable.ic_ingot),
            Items("Coin", "Coins are the currency trading of this game and can be sent to the player or used to buy upgrades", R.drawable.ic_money)
        )

        val invRecycler = view.findViewById<RecyclerView>(R.id.invRecycler)
        invRecycler.adapter = InvAdapter(invList)
        invRecycler.layoutManager = LinearLayoutManager(this.activity)
    }
}