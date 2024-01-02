entrada = int(input())

segundos = entrada % 60 
entrada //= 60
minutos = entrada % 60
entrada //= 60
horas = entrada % 60
print(f'{horas}:{minutos}:{segundos}')
