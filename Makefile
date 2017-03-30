LIBS=-r:MonoGame.Framework.dll
TARGET=-target:winexe -out:bin/Program.exe

OS:=$(shell uname)

ifeq ($(OS),Linux)
MONOGAME=/usr/lib/mono/xbuild/MonoGame/v3.0/Assemblies/DesktopGL
endif

ifeq ($(OS),Darwin)
MONOGAME=/Library/Frameworks/MonoGame.framework/Current/Assemblies/DesktopGL
endif

LIBPATHS=-lib:$(MONOGAME)

all: compile


clean:
	rm -rf bin

compile: copy_libs
	mkdir -p bin
	mcs $(LIBPATHS) $(LIBS) $(TARGET) -recurse:src/*.cs

copy_libs:
	mkdir -p bin
	cp -nr $(MONOGAME)/* bin

run:
	cd bin; \
	mono Program.exe
