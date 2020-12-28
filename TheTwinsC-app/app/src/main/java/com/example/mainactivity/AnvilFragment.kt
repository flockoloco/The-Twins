package com.example.mainactivity

import android.content.ClipData
import android.content.ClipDescription
import android.content.Context
import android.graphics.Color.*
import android.hardware.*
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.util.Log
import android.view.DragEvent
import androidx.fragment.app.Fragment
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.Toast
import kotlinx.android.synthetic.main.fragment_anvil.*
import kotlinx.android.synthetic.main.fragment_anvil.view.*
import java.io.IOException

class AnvilFragment : Fragment(R.layout.fragment_anvil), SensorEventListener {

    var dragged: Int = 0

    var sensor: Sensor? = null
    var sensorManager: SensorManager? = null

    var forge = 0

    val looper = Handler(Looper.getMainLooper())


    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)


        looper.post(object : Runnable {
            override fun run() {
                if (getView() != null) {
                    if (dragged == 1) {
                        Progress_bar_dec()
                    }
                }
                looper.postDelayed(this, 1500)
            }
        })

        //Motion Sensor
        sensorManager = activity?.getSystemService(Context.SENSOR_SERVICE) as SensorManager
        sensor = sensorManager!!.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)


        //--------------------------------------------------------

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
            if (dragged == 1) {
                ProgressBar.incrementProgressBy(2)
                //ProgressBar.progressTintList = ColorStateList.valueOf(RED) -> assim que troca de cor da barra de progresso, mas nao é tao bom quanto um gradiant
            }
        }
    }

    private fun Progress_bar_dec() {
        ProgressBar.incrementProgressBy(-1)
    }

    // Creates a new drag event listener
    private val dragListen = View.OnDragListener { view, event ->
        when (event.action) {

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
                Toast.makeText(view.context, "esse é o numero ", Toast.LENGTH_SHORT).show()

                view.invalidate()

                val v = event.localState as View
                val owner = v.parent as ViewGroup
                owner.removeView(v)
                val destination = view as LinearLayout
                destination.addView(v)
                v.visibility = View.VISIBLE

                //what ever ta a funcionar, porque dragtop nao dragbot?
                dragged = if (owner.tag.toString() == "dragTop") {
                    1
                } else {
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

    override fun onResume() {
        super.onResume()
        sensorManager!!.registerListener(this, sensor, SensorManager.SENSOR_DELAY_NORMAL)
    }

    override fun onPause() {
        super.onPause()
        sensorManager!!.unregisterListener(this)
    }

    override fun onSensorChanged(event: SensorEvent?) {
        if (event!!.values[0] > 2) {
            //supostamente o if de baixo funciona mas como nao consigo fazer no meu telemovel nao sei oq esperar :( POGGS
            //if (event!!.values[1] > 9.82 || event!!.values[1] < 9.80)
            forge += 1
        }
        if(ProgressBar.progress > 75){
            if(forge == 5 && dragged == 1){
                Resources.Bars += 1
                forge = 0
            }
        }
    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {
    }
}