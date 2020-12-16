package com.example.mainactivity

import android.content.ClipData
import android.content.ClipDescription
import android.os.Bundle
import android.view.DragEvent
import androidx.fragment.app.Fragment
import android.view.View
import android.view.ViewGroup
import android.view.ViewParent
import android.widget.LinearLayout
import android.widget.Toast
import kotlinx.android.synthetic.main.fragment_anvil.*

class AnvilFragment : Fragment(R.layout.fragment_anvil) {

    var batata: Int = 0

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        dragBot.setOnDragListener(dragListen)
        dragTop.setOnDragListener(dragListen)
        //drag and drop PÁ
        AnvilIngot.setOnLongClickListener {
            val clipText = "Drag and drop ingot"
            val item = ClipData.Item(clipText)
            val mimeTypes = arrayOf(ClipDescription.MIMETYPE_TEXT_PLAIN)
            val data = ClipData(clipText, mimeTypes, item)

            val dragShadowBuilder = View.DragShadowBuilder(it)
            it.startDragAndDrop(data, dragShadowBuilder, it, 0)

            it.visibility = View.INVISIBLE
            true
        }

        //Progress bar
        clickablearea.setOnClickListener {
            if(batata == 1) {
                ProgressBar.incrementProgressBy(1)
                //mudar a cor da barra
            }
        }
    }

    // Creates a new drag event listener
    private val dragListen = View.OnDragListener {view, event ->
        when(event.action){

            DragEvent.ACTION_DRAG_STARTED -> {
                event.clipDescription.hasMimeType(ClipDescription.MIMETYPE_TEXT_PLAIN)
            }

            DragEvent.ACTION_DRAG_ENTERED -> {
                view.invalidate()
                true
            }

            DragEvent.ACTION_DRAG_LOCATION -> true

            DragEvent.ACTION_DRAG_EXITED -> {
                view.invalidate()
                true
            }

            // unico drag event importante
            DragEvent.ACTION_DROP -> {
                val item = event.clipData.getItemAt(0)
                val dragData = item.text
                Toast.makeText(view.context, dragData, Toast.LENGTH_SHORT).show()

                view.invalidate()

                val v = event.localState as View
                val owner = v.parent as ViewGroup
                owner.removeView(v)
                val destination = view as LinearLayout
                destination.addView(v)
                v.visibility = View.VISIBLE

                //what ever ta a funcionar, porque dragtop nao dragbot?
                batata = if(owner.tag.toString() == "dragTop"){
                    1
                }else {
                    0
                }

                true
            }
            DragEvent.ACTION_DRAG_ENDED -> {
                view.invalidate()
                val v = event.localState as View
                v.visibility = View.VISIBLE
                true
            }
            else -> false
        }
    }
}