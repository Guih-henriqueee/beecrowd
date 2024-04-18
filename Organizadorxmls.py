import os
import logging
from tqdm import tqdm
from lxml import etree as ET

# Configura o logging
logging.basicConfig(filename='logs\\processamento.log', level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

def obter_cfop(xml_file):
    try:
        # Analisa o XML para obter o CFOP
        tree = ET.parse(xml_file)
        root = tree.getroot()
        cfop_element = root.find(".//{http://www.portalfiscal.inf.br/nfe}CFOP")
        if cfop_element is not None:
            return cfop_element.text
        else:
            logging.warning(f"CFOP não encontrado para o arquivo {xml_file}.")
            return None
    except Exception as e:
        logging.error(f"Erro ao obter o CFOP do arquivo {xml_file}: {e}")
        return None

def obter_numero_nf(xml_file):
    try:
        # Analisa o XML para obter o número da nota fiscal
        tree = ET.parse(xml_file)
        root = tree.getroot()
        numero_nf_element = root.find(".//{http://www.portalfiscal.inf.br/nfe}nNF")
        if numero_nf_element is not None:
            return numero_nf_element.text
        else:
            logging.warning(f"Número da NF não encontrado para o arquivo {xml_file}.")
            return None
    except Exception as e:
        logging.error(f"Erro ao obter o número da NF do arquivo {xml_file}: {e}")
        return None

def obter_serie_nf(xml_file):
    try:
        # Analisa o XML para obter a série da nota fiscal
        tree = ET.parse(xml_file)
        root = tree.getroot()
        serie_nf_element = root.find(".//{http://www.portalfiscal.inf.br/nfe}serie")
        if serie_nf_element is not None:
            return serie_nf_element.text
        else:
            logging.warning(f"Série da NF não encontrada para o arquivo {xml_file}.")
            return None
    except Exception as e:
        logging.error(f"Erro ao obter a série da NF do arquivo {xml_file}: {e}")
        return None

def renomear_arquivos(diretorio, prefixos, serieNota):
    logging.info(f"Iniciando renomeação de arquivos no diretório {diretorio}.")
    # Obtém a lista de arquivos e diretórios no diretório atual
    arquivos_e_pastas = os.listdir(diretorio)

    # Configura a barra de progresso
    barra_progresso = tqdm(total=len(arquivos_e_pastas), desc='Renomeando arquivos no {diretorio}', unit='item(s)')

    for item in arquivos_e_pastas:
        caminho_atual = os.path.join(diretorio, item)
        
        if os.path.isfile(caminho_atual) and caminho_atual.lower().endswith('.xml'):
            # Se o item é um arquivo XML, renomeia conforme o CFOP
            cfop = obter_cfop(caminho_atual)
            if cfop:
                # Verifica se o CFOP está no catálogo de prefixos
                if cfop in prefixos:
                    # Obtém o número da NF e a série do arquivo XML
                    numero_nf = obter_numero_nf(caminho_atual)
                    serie_nf = obter_serie_nf(caminho_atual)
                    
                    if numero_nf and serie_nf:
                        # Constrói o novo nome do arquivo com o prefixo, número da NF, série e um sufixo para garantir a unicidade
                        novo_nome = f"{numero_nf}_{prefixos[cfop]}_{serieNota[serie_nf]}_{cfop}_{serie_nf}.xml"
                        
                        # Verifica se o novo nome já existe no diretório
                        if novo_nome in arquivos_e_pastas:
                            # Se já existe, adiciona um sufixo numérico ao novo nome
                            contador = 1
                            while f"{novo_nome}_{contador}" in arquivos_e_pastas:
                                contador += 1
                            novo_nome = f"{novo_nome}_{contador}"
                        
                        # Constrói o novo caminho do arquivo
                        novo_caminho = os.path.join(diretorio, novo_nome)
                        
                        # Renomeia o arquivo
                        os.rename(caminho_atual, novo_caminho)
                        
                        # Atualiza a barra de progresso
                        barra_progresso.update(1)
                    else:
                        logging.warning(f"Número da NF ou série não encontrados para o arquivo {item}. Não foi renomeado.")
                else:
                    logging.warning(f"CFOP {cfop} não encontrado no catálogo de prefixos para o arquivo {item}. Não foi renomeado.")
            else:
                logging.warning(f"CFOP não encontrado para o arquivo {item}. Não foi renomeado.")
        elif os.path.isdir(caminho_atual):
            # Se o item é um diretório, chama a função recursivamente para processar seus arquivos
            renomear_arquivos(caminho_atual, prefixos, serieNota)
    
    # Fecha a barra de progresso quando o processo estiver completo
    barra_progresso.close()
    logging.info(f"Renomeação de arquivos concluída no diretório {diretorio}.")

def mover_renomeados(diretorio, diretorioDestino, serieNota, PastasArquivosRenomeados):
    logging.info(f"Iniciando movimentação de arquivos renomeados de {diretorio} para {diretorioDestino}.")
    arquivos_e_pastas = os.listdir(diretorio)

    # Configura a barra de progresso
    barra_progresso = tqdm(total=len(arquivos_e_pastas), desc=f'Movendo arquivos de {diretorio} para {diretorioDestino}', unit='item(s)')

    for item in arquivos_e_pastas:
        caminho_atual = os.path.join(diretorio, item)
        caminho_destino = None

        # Verifica se o item é um arquivo
        if os.path.isfile(caminho_atual):
            # Extrai o sufixo do nome do arquivo
            sufixo = item.split('_')[-1].split('.')[0]

            # Verifica se o sufixo está na lista de séries definida
            if sufixo in PastasArquivosRenomeados:
                # Constrói o diretório de destino com base no sufixo
                caminho_destino = os.path.join(diretorioDestino, PastasArquivosRenomeados[sufixo])

                # Verifica se o diretório de destino existe, senão cria
                if not os.path.exists(caminho_destino):
                    os.makedirs(caminho_destino)
                    logging.info(f"Diretório de destino criado: {caminho_destino}")

                # Move o arquivo para o diretório de destino
                novo_caminho = os.path.join(caminho_destino, item)
                os.rename(caminho_atual, novo_caminho)
                logging.info(f"Arquivo movido para {caminho_destino}: {item}")

        # Atualiza a barra de progresso apenas para arquivos
        barra_progresso.update(1)
        
    # Fecha a barra de progresso quando o processo estiver completo
    barra_progresso.close()
    logging.info(f"Concluída movimentação de arquivos renomeados de {diretorio} para {diretorioDestino}.")

def apagar_arquivos(diretorio, serieNotaBlackList):
    logging.info(f"Iniciando exclusão de arquivos em {diretorio}.")
    # Obtém a lista de arquivos e diretórios no diretório atual
    arquivos_e_pastas = os.listdir(diretorio)

    # Imprime a lista de exclusão para fins de depuração
    logging.info("Lista de exclusão:" + str(serieNotaBlackList))

    # Configura a barra de progresso
    barra_progresso = tqdm(total=len(arquivos_e_pastas), desc=f'Apagando arquivos em {diretorio}', unit='item(s)')

    for item in arquivos_e_pastas:
        caminho_atual = os.path.join(diretorio, item)

        # Verifica se o item é um arquivo
        if os.path.isfile(caminho_atual):
            # Extrai a série do arquivo
            sufixo = item.split('_')[-1].split('.')[0]

            # Imprime o sufixo do arquivo para fins de depuração
            logging.info("Sufixo do arquivo:" + sufixo)

            # Verifica se a série do arquivo está na lista de exclusão
            if sufixo not in serieNotaBlackList:
                try:
                    # Apaga o arquivo
                    os.remove(caminho_atual)
                    logging.info(f"Arquivo apagado: {caminho_atual}")
                except Exception as e:
                    logging.error(f"Erro ao apagar o arquivo {caminho_atual}: {e}")
                    continue
        
        # Atualiza a barra de progresso para cada item
        barra_progresso.update(1)

    # Fecha a barra de progresso quando o processo estiver completo
    barra_progresso.close()
    logging.info(f"Concluída exclusão de arquivos em {diretorio}.")


if __name__ == "__main__":
    # Diretório onde os arquivos estão localizados
    diretorio = "Vendas"
    diretorioDestino = "Renomeadas"
    
    
    # Catálogo de prefixos baseados no CFOP do XML
    prefixos = {
        "5405": "NF_VENDAS",
        "6106": "NF_VENDAS",
        "5106": "NF_VENDAS",
        "5102": "NF_VENDAS",
        "6102": "NF_VENDAS",
        "6108": "NF_VENDAS",
        "6404": "NF_VENDAS",
        "6949": "NF_REM_MERC_DEP_TEMP",
        "6905": "NF_REM_MERC_DEP_TEMP",
        "5905": "NF_REM_MERC_DEP_TEMP",
        "5415": "NF_REM_MERC_DEP_TEMP",
        "6415": "NF_REM_MERC_DEP_TEMP",
        "5949": "NF_RET_SIMB_OS",
        "5906": "NF_RET_SIMB_OS",
        "6906": "NF_RET_SIMB_OS",
        "1949": "NF_RET_SIMB_OE",
        "1907": "NF_RET_SIMB_OE",
        "2907": "NF_RET_SIMB_OE",
        "2949": "NF_RET_SIMB_OE",
        "1202": "NF_DEV",
        "2202": "NF_DEV",
        "1411": "NF_DEV",
        "2411": "NF_DEV",
        "1415": "NF_DEV",
        "2415": "NF_DEV"
    }
    serieNota = {
        "1": "Inpower",
        "2": "MELI",
        "3": "B2W",
        "4": "AMAZON",
        "5": "MAGALU",
        
    }
    # Lista de séries a serem excluídas
    serieNotaBlackList = ["4", "2", "3", "5"]

    PastasArquivosRenomeados = {
    "2": "MELI",
    "3": "B2W",
    "4": "AMAZON",
    "5": "MAGALU"
    }

renomear_arquivos(diretorio, prefixos, serieNota)
apagar_arquivos(diretorio, serieNotaBlackList)
mover_renomeados(diretorio, diretorioDestino, serieNota, PastasArquivosRenomeados)
