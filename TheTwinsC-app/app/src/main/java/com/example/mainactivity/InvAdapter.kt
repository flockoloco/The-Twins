package com.example.mainactivity


import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.view.menu.MenuView
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.deliverydialog.*
import kotlinx.android.synthetic.main.inventory_layout.view.*

class InvAdapter(var itemInv: List<Inventory>) : RecyclerView.Adapter<InvAdapter.InvViewHolder>() {

    inner class InvViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): InvViewHolder {
        val view =
            LayoutInflater.from(parent.context).inflate(R.layout.inventory_layout, parent, false)
        return InvViewHolder(view)

    }

    override fun getItemCount(): Int {
        return itemInv.size
    }

    override fun onBindViewHolder(holder: InvViewHolder, position: Int) {
        holder.itemView.apply {
            invName.text = itemInv[position].name
            invDescription.text = itemInv[position].details
            invIcon.setImageResource(itemInv[position].icon)
        }
        holder.itemView.setOnClickListener { view ->
            val dialogBox = LayoutInflater.from(view.context).inflate(R.layout.deliverydialog, null)
            val builder = AlertDialog.Builder(view.context)
                .setView(dialogBox)
                .create()
            builder.show()

            if (position == 0) {
                builder.textView2.text = "How many ores do you want to send to your brother?"
                builder.imageView.setImageResource(R.drawable.ic_gold_ingot)

                builder.closeImage.setOnClickListener {
                    builder.dismiss()
                }
                var count = 0
                builder.button.setOnClickListener{
                    count--
                    if(count < 0){
                        count = 0
                    }
                    builder.textView.text = "$count"
                }

                builder.button2.setOnClickListener{
                    count++
                    builder.textView.text = "$count"
                }

                builder.button3.setOnClickListener{
                    Toast.makeText(view.context, "$count Ores sent", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 1) {
                builder.textView2.text = "How many ingots do you want to send to your brother?"
                builder.imageView.setImageResource(R.drawable.ic_ingot)

                builder.closeImage.setOnClickListener {
                    builder.dismiss()
                }
                var count = 0
                builder.button.setOnClickListener{
                    count--
                    if(count < 0){
                        count = 0
                    }
                    builder.textView.text = "$count"
                }

                builder.button2.setOnClickListener{
                    count++
                    builder.textView.text = "$count"
                }

                builder.button3.setOnClickListener{
                    Toast.makeText(view.context, "$count Ingots sent", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 2) {
                builder.textView2.text = "How many coins do you want to send to your brother?"
                builder.imageView.setImageResource(R.drawable.ic_money)

                builder.closeImage.setOnClickListener {
                    builder.dismiss()
                }
                var count = 0
                builder.button.setOnClickListener{
                    count--
                    if(count < 0){
                        count = 0
                    }
                    builder.textView.text = "$count"
                }

                builder.button2.setOnClickListener{
                    count++
                    builder.textView.text = "$count"
                }

                builder.button3.setOnClickListener{
                    Toast.makeText(view.context, "$count Coins sent", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
        }
    }
}