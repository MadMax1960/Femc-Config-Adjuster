@echo off
setlocal

where magick.exe >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo ImageMagick is not installed or not in PATH.
    pause
    exit /b 1
)

if "%~1"=="" (
    echo Please drag and drop a folder onto this script.
    pause
    exit /b 1
)

set "input_folder=%~1"

for /r "%input_folder%" %%f in (image.webp) do (
    set "input_file=%%f"
    set "output_file=%%~dpnf_small%%~xf"
    
    magick "%%f" -resize 384x216 "%%~dpnf_small%%~xf"
)

echo Done resizing images.
pause
endlocal
