import os
from reportlab.pdfgen import canvas

posX = 20
posY = 810

nomEmpresa = "Metaleria Metalica del cobre y Asociados"
cantAccidentes = "0"
porcentaje = "7"
comp = "mas"

linea00 = "Este informe tiene la finalidad de mostrar las estadisticas de este mes con respecto a la taza de\n accidentes de la empresa " + nomEmpresa + " y un resumen de las\n respuestas que se han dado de parte de nuestra empresa, esto con la finalidad que tenga constancia\n de los eventos ocurridos en este mes."
linea01 = "En este mes han ocurrido un total de " + cantAccidentes + " accidentes, lo que en comparacion con el mes pasado es un\n " + porcentaje +  "% " + comp + " que el mes pasado."
linea02 = "Ante estos incidentes la respuesta de parte de nuestra empresa fue la siguiente:"

doc = canvas.Canvas("hola-mundo.pdf")

parrafo00 = doc.beginText(posX, posY)
parrafo00.textLines(linea00)

parrafo01 = doc.beginText(posX, posY - 80)
parrafo01.textLines(linea01)


parrafo02 = doc.beginText(posX, posY - 120)
parrafo02.textLines(linea02)

doc.drawText(parrafo00)
doc.drawText(parrafo01)
doc.drawText(parrafo02)

doc.save()
os.system("cls")