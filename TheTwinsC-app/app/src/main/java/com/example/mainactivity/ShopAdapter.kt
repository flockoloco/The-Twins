package com.example.mainactivity


import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.deliverydialog.*
import kotlinx.android.synthetic.main.items_layout.view.*

class ShopAdapter(var itemInv: List<Items>) : RecyclerView.Adapter<ShopAdapter.ShopViewHolder>() {

    inner class ShopViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView)

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ShopViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.items_layout, parent, false)
        return ShopViewHolder(view)

    }

    override fun getItemCount(): Int {
        return itemInv.size
    }

    override fun onBindViewHolder(holder: ShopViewHolder, position: Int) {
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
                builder.textView2.text = "How many ores do you want to buy / sell ?"
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
                    Toast.makeText(view.context, "$count Ores bought", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 1) {
                builder.textView2.text = "How many ingots do you want to buy / sell?"
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
                    Toast.makeText(view.context, "$count Ingots bought", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 2) {
                builder.textView2.text = "How many Mine Speed upgrades do you want buy / sell?"
                builder.imageView.setImageResource(R.drawable.ic_upgrade)

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
                    Toast.makeText(view.context, "$count Mine Speed bought", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 3) {
                builder.textView2.text = "How many Mine Harvest upgrades do you want buy / sell?"
                builder.imageView.setImageResource(R.drawable.ic_upgrade)

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
                    Toast.makeText(view.context, "$count Mine Harvest bought", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
            if (position == 4) {
                builder.textView2.text = "How many Mine Ores upgrades do you want buy / sell?"
                builder.imageView.setImageResource(R.drawable.ic_upgrade)

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
                    Toast.makeText(view.context, "$count Mine Ores bought", Toast.LENGTH_LONG).show()
                    builder.dismiss()
                }
            }
        }
    }
}