entrada = float(input())


if 0 <= entrada <= 25: 
    print("Intervalo [0,25]")
elif 25 < entrada <= 50: 
    print("Intervalo (25,50]")
elif 50 < entrada <= 75: 
    print("Intervalo (50,75]")
elif entrada <= 100 and entrada > 0: 
    print("Intervalo (75,100]")
else:
    print("Fora de intervalo")
