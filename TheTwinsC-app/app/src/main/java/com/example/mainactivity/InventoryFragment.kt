package com.example.mainactivity

import android.content.Intent
import android.graphics.Color
import android.graphics.drawable.ColorDrawable
import android.os.Bundle
import android.os.PersistableBundle
import android.view.LayoutInflater
import androidx.fragment.app.Fragment
import android.view.View
import android.view.ViewGroup
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.activity_main.*

class InventoryFragment : Fragment(R.layout.fragment_inventory) {

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        var invList = mutableListOf(
            Items(
                "Coin x${Resources.Gold}",
                "Coins are the currency trading of this game!",
                R.drawable.ic_money
            ),
            Items(
                "Ore x${Resources.Nuggets}",
                "Ores are gathered every hour inside the mine",
                R.drawable.ic_gold_ingot
            ),
            Items(
                "Ingot x${Resources.Bars}",
                "Ingots are forged in the anvil, it can be traded in the shop or sent to the player",
                R.drawable.ic_ingot
            ),
            Items(
                "Mine Speed Upgrade",
                "approximately ${String.format("%.1f" ,(Resources.Minespd.toDouble() / 60))}/h left, the ores are gathered every hour",
                R.drawable.ic_upgrade
            ),
            Items(
                "Mine Harvest Upgrade",
                "approximately ${String.format("%.1f" ,(Resources.MineHarvest.toDouble() / 60))}/h left, the amount of ores gathered are x2",
                R.drawable.ic_upgrade
            ),
            Items(
                "Mine Ores Upgrade",
                "Permanent ores upgrade, +${Resources.PermUpgrade} ores per hour",
                R.drawable.ic_upgrade
            )
        )

        val invRecycler = view.findViewById<RecyclerView>(R.id.invRecycler)
        invRecycler.adapter = InvAdapter(invList)
        invRecycler.layoutManager = LinearLayoutManager(this.activity)
    }
}