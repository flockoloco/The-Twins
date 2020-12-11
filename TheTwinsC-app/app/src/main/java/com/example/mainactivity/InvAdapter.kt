package com.example.mainactivity

import android.graphics.drawable.Drawable
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.recyclerview.widget.RecyclerView

class InvAdapter (var itemInv: List<Inventory>, private val clickListener: (Inventory) -> Unit): RecyclerView.Adapter<InvAdapter.InvViewHolder>() {

    inner class InvViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): InvViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.inventory_layout, parent, false)
        return InvViewHolder(view)
    }

    override fun getItemCount(): Int {
        return itemInv.size
    }

    override fun onBindViewHolder(holder: InvViewHolder, position: Int) {
        holder.itemView.apply {
            findViewById<TextView>(R.id.invName).text = itemInv[position].name
            findViewById<TextView>(R.id.invDescription).text = itemInv[position].details
            findViewById<ImageView>(R.id.invIcon).setImageResource(itemInv[position].icon)
        }
    }
}