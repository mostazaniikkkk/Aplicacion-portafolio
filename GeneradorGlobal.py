import os
from reportlab.pdfgen import canvas

posX = 20
posY = 810

varCasos = "incremento"
clienteNuevos = "256"
porcentaje = "100"

cantAtrasos = "256"
varAtrasos = "incremento"
porAtrasos = "100"

linea00 = "Este mes la empresa ha visto un " + varCasos + " lo que en comparacion al mes pasado representa un " + porcentaje +  " %\n de " + varCasos + "en sus clientes."
linea01 = "De estos clientes un " + cantAtrasos + " se han atrasado con el pago del servicio, esto en contraste al mes pasado\n representa un " + varAtrasos + " del " + porAtrasos + " %. Ante esto se recomienda llegar a una negociacion con el cliente o\n de plano cancelar el contrato a traves del modulo de administracion."
doc = canvas.Canvas("InformeGlobal.pdf")

parrafo00 = doc.beginText(posX, posY)
parrafo00.textLines(linea00)

parrafo01 = doc.beginText(posX, posY - 40)
parrafo01.textLines(linea01)

doc.drawText(parrafo00)
doc.drawText(parrafo01)

doc.save()
os.system("cls")