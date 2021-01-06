package com.example.mainactivity

import android.graphics.Point
import android.os.Bundle
import android.view.*
import androidx.fragment.app.DialogFragment
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.email_dialog.view.*


class EmailDialog : DialogFragment() {

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val rootView = inflater.inflate(R.layout.email_dialog, container)

        var emailList = mutableListOf(
            Items("Ore", "Ores are gathered every hour inside the mine", R.drawable.ic_gold_ingot),
            Items(
                "Ingot",
                "Ingots are forged in the anvil, it can be traded in the shop or sent to the player",
                R.drawable.ic_ingot
            ),
            Items(
                "Mine Speed",
                "Temporary speed upgrade, the ores are gathered every 1/2 hour",
                R.drawable.ic_upgrade
            ),
            Items(
                "Mine Harvest",
                "Temporary harvest upgrade, the amount of ores gathered are x2",
                R.drawable.ic_upgrade
            ),
            Items(
                "Mine Ores",
                "Permanent ores upgrade, the amount of ores gathered are +1",
                R.drawable.ic_upgrade
            )
        )

        val MylistView = rootView.findViewById<RecyclerView>(R.id.emailRecycler)
        MylistView.adapter = EmailAdapter(emailList)
        MylistView.layoutManager = LinearLayoutManager(this.activity)

        rootView.closeEmail.setOnClickListener {
            dismiss()
        }

        return rootView
    }

    override fun onStart() {
        if (dialog != null) {
            dialog!!.window?.setLayout(
                ViewGroup.LayoutParams.MATCH_PARENT,
                ViewGroup.LayoutParams.MATCH_PARENT
            )
        }
        super.onStart()
    }

}