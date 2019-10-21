@echo off
echo Generating new images...
RTImageGenerator.exe 0
timeout /t 1
echo Removing image...
del ImageOutput*.png
RTImageGenerator.bat