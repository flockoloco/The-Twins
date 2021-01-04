package com.example.mainactivity


import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.deliverydialog.*
import kotlinx.android.synthetic.main.items_layout.view.*

class InvAdapter(var itemInv: List<Items>) : RecyclerView.Adapter<InvAdapter.InvViewHolder>() {

    inner class InvViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): InvViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.items_layout, parent, false)
        return InvViewHolder(view)

    }

    override fun getItemCount(): Int {
        return itemInv.size
    }

    override fun onBindViewHolder(holder: InvViewHolder, position: Int) {
        holder.itemView.apply {
            itemTitle.text = itemInv[position].name
            itemDescription.text = itemInv[position].details
            itemIcon.setImageResource(itemInv[position].icon)
        }
        holder.itemView.setOnClickListener { view ->
            val dialogBox = LayoutInflater.from(view.context).inflate(R.layout.deliverydialog, null)
            val builder = AlertDialog.Builder(view.context)
                .setView(dialogBox)
                .create()
            builder.show()

            if (position == 0) {
                builder.shopText.text = "How many ores do you want to send to your brother?"
                builder.shopImage.setImageResource(R.drawable.ic_gold_ingot)

                builder.closeShop.setOnClickListener {
                    builder.dismiss()
                }
                var count = 0
                builder.shopDecrease.setOnClickListener{
                    count--
                    if(count < 0){
                        count = 0
                    }
                    builder.shopAmount.text = "$count"
                }

                builder.shopIncrease.setOnClickListener{
                    count++
                    builder.shopAmount.text = "$count"
                }

                builder.button3.setOnClickListener{
                    Toast.makeText(view.context, "$count Ores sent", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 1) {
                builder.shopText.text = "How many ingots do you want to send to your brother?"
                builder.shopImage.setImageResource(R.drawable.ic_ingot)

                builder.closeShop.setOnClickListener {
                    builder.dismiss()
                }
                var count = 0
                builder.shopDecrease.setOnClickListener{
                    count--
                    if(count < 0){
                        count = 0
                    }
                    builder.shopAmount.text = "$count"
                }

                builder.shopIncrease.setOnClickListener{
                    count++
                    builder.shopAmount.text = "$count"
                }

                builder.button3.setOnClickListener{
                    Toast.makeText(view.context, "$count Ingots sent", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 2) {
                builder.shopText.text = "How many coins do you want to send to your brother?"
                builder.shopImage.setImageResource(R.drawable.ic_money)

                builder.closeShop.setOnClickListener {
                    builder.dismiss()
                }
                var count = 0
                builder.shopDecrease.setOnClickListener{
                    count--
                    if(count < 0){
                        count = 0
                    }
                    builder.shopAmount.text = "$count"
                }

                builder.shopIncrease.setOnClickListener{
                    count++
                    builder.shopAmount.text = "$count"
                }

                builder.button3.setOnClickListener{
                    Toast.makeText(view.context, "$count Coins sent", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
        }
    }
}