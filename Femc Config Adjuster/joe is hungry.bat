@echo off
setlocal

REM Check if ImageMagick's magick command is available
where magick.exe >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo ImageMagick is not installed or not in PATH.
    pause
    exit /b 1
)

REM Check if a folder was dragged onto the script
if "%~1"=="" (
    echo Please drag and drop a folder onto this script.
    pause
    exit /b 1
)

REM Set the folder to the one dragged onto the script
set "input_folder=%~1"

REM Loop through all 'image.webp' files in the folder and its subfolders
for /r "%input_folder%" %%f in (image.webp) do (
    set "input_file=%%f"
    set "output_file=%%~dpnf_small%%~xf"
    
    REM Resize the image to 384x216 and save as _small.webp
    magick "%%f" -resize 384x216 "%%~dpnf_small%%~xf"
)

echo Done resizing images.
pause
endlocal
