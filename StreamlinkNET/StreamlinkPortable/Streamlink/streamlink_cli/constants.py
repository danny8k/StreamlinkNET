import os

from streamlink import __version__ as LIVESTREAMER_VERSION

DEFAULT_PLAYER_ARGUMENTS = u"{filename}"
DEFAULT_STREAM_METADATA = {
    "title": u"Unknown Title",
    "author": u"Unknown Author",
    "category": u"No Category",
    "game": u"No Game/Category"
}
SUPPORTED_PLAYERS = {  # these are the players that streamlink knows how to set the window title for with `--title`. key names are used in help text
    # name: possible binary names (linux/mac and windows)
    "vlc": ["vlc", "vlc.exe"],
    "mpv": ["mpv", "mpv.exe"]
}

APPDATA = os.path.abspath(__file__)
for i in range(3):
    APPDATA = os.path.dirname(APPDATA)
APPDATA = os.path.normpath(APPDATA)

CUSTOM_APPDATA = os.path.join(APPDATA, "CUSTOM_APPDATA")
if os.path.isfile(CUSTOM_APPDATA):
    with open(CUSTOM_APPDATA, 'r') as CUSTOM_APPDATA_FILE:
        APPDATA = CUSTOM_APPDATA_FILE.read().replace('"','')
        APPDATA = os.path.normpath(APPDATA)

CONFIG_FILES = [os.path.join(APPDATA, "streamlinkrc")]
PLUGINS_DIR = os.path.join(APPDATA, "plugins")

STREAM_SYNONYMS = ["best", "worst"]
STREAM_PASSTHROUGH = ["hls", "http", "rtmp"]

__all__ = [
    "CONFIG_FILES", "DEFAULT_PLAYER_ARGUMENTS", "LIVESTREAMER_VERSION",
    "PLUGINS_DIR", "STREAM_SYNONYMS", "STREAM_PASSTHROUGH"
]