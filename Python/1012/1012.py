pi = 3.14159
dados = input().split()
A = float(dados[0])
B = float(dados[1])
C = float(dados[2])
	
TRIANGULO =  (A * C) / 2
CIRCULO = (C ** 2) * pi
TRAPEZIO = ((A + B) * C) / 2
QUADRADO = B ** 2
RETANGULO = A * B


print(f'TRIANGULO: {TRIANGULO:.3f}\nCIRCULO: {CIRCULO:.3f}\nTRAPEZIO: {TRAPEZIO:.3f}\nQUADRADO: {QUADRADO:.3f}\nRETANGULO: {RETANGULO:.3f}')