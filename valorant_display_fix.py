import os
import configparser

# Path to the GameUserSettings.ini file
CONFIG_DIR = os.path.join(os.environ['USERPROFILE'], r'AppData\Local\VALORANT\Saved\Config')
# The WindowsClient folder may vary based on locale; we attempt to locate it dynamically

ini_path = None
for root, dirs, files in os.walk(CONFIG_DIR):
    for file in files:
        if file == 'GameUserSettings.ini':
            ini_path = os.path.join(root, file)
            break
    if ini_path:
        break

if not ini_path:
    raise FileNotFoundError('GameUserSettings.ini not found in VALORANT config directory')

print(f'Found config: {ini_path}')

config = configparser.ConfigParser()
config.read(ini_path)

# Ensure the SystemSettings section exists
if 'SystemSettings' not in config:
    config['SystemSettings'] = {}

settings = config['SystemSettings']
settings['ResolutionSizeX'] = '5120'
settings['ResolutionSizeY'] = '1440'
settings['FullscreenMode'] = '1'  # 0=pencereli, 1=sınırsız pencereli, 2=tam ekran
settings['LastConfirmedFullscreenMode'] = '1'

with open(ini_path, 'w') as configfile:
    config.write(configfile)

print('Valorant config updated. Restart the game to apply changes.')
