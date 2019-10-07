@echo off
echo Generating new images...
RTImageGenerator.exe 0
RTImageGenerator.exe 1
RTImageGenerator.exe 2
timeout /t 3
echo Removing image...
del ImageOutput*.png
RTImageGenerator.bat