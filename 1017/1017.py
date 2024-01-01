autonomia = 12
tempo = int(input())
velocidade = int(input())

distancia  = tempo * velocidade
consumo = distancia / autonomia

print(f'{consumo:.3f}')
