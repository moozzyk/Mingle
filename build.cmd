mkdir build\duktape
python duktape\tools\configure.py --output-dir=build\duktape
pushd build
cmake ..
make .
msbuild duktape.sln
popd
