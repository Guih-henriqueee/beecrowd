numeros = input() # entrada unica de 4 numeros inteiros
numeros = numeros.split(" ") # delimitador comum para criar uma lista

A = int(numeros[0]) # Pega o numero na primeira posição
B = int(numeros[1]) # Pega o numero na segunda posição
C = int(numeros[2]) # Pega o numero na terceira posição
D = int(numeros[3]) # Pega o numero na quarta posição

msg1 = "Valores aceitos"
msg2 = "Valores nao aceitos"


if (A % 2 != 0): # Verifica o primeiro critério eliminatório master
    print (msg2)

else:
    if (D > A) and (B > C) and (( A + B) < (C + D)) and (C > 0 and D > 0): # Lógica aninhada
        print(msg1)

    else:
        print(msg2)

