mkdir build\duktape
python duktape\tools\configure.py --output-dir=build\duktape --dll
pushd build
cmake ..
msbuild duktape.sln
popd
