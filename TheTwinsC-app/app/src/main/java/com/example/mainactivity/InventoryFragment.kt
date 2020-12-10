package com.example.mainactivity

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class InventoryFragment : Fragment(R.layout.fragment_inventory) {
    private var inventoryLayout: RecyclerView.LayoutManager? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_inventory, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        var invList = mutableListOf(
                Inventory("blablabla", "blablabla", 2)
        )
        val invRecycler = view?.findViewById<RecyclerView>(R.id.invRecycler)
        invRecycler.adapter = InvAdapter(invList)
        invRecycler.layoutManager = LinearLayoutManager(this.activity)
    }
}