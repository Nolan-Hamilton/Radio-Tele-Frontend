@echo off
echo Generating new image...
RTImageGenerator.exe 
timeout /t 1
echo Removing image...
del ImageOutput*.png
RTImageGenerator.bat