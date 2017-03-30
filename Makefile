# NOTE: This Makefile requires Mono and MonoGame. And does not support shitty
#       operating systems (e.g. Windows).

#---------------------------------------
# CONSTANTS
#---------------------------------------

BINDIR      = bin
COMPILER    = mcs
CONTENTFILE = content.mgcb
FLAGS       = -target:winexe
LIBPATHS    = -lib:$(MONOGAME)
LIBS        = MonoGame.Framework.dll
OBJDIR      = obj
SRCDIR      = src
TARGET      = Program.exe

#---------------------------------------
# INITIALIZATION
#---------------------------------------

# Find all content to build with MonoGame Content Builder.
CONTENT := $(wildcard Content/*)

# Linux and macOS have different paths to the MonoGame library files, so make
# sure to set them up properly. No Windows support here, lol!
OS := $(shell uname)

ifeq ($(OS), Linux)
MONOGAME = /usr/lib/mono/xbuild/MonoGame/v3.0/Assemblies/DesktopGL
endif

ifeq ($(OS), Darwin)
MONOGAME = /Library/Frameworks/MonoGame.framework/Current/Assemblies/DesktopGL
endif

#---------------------------------------
# TARGETS
#---------------------------------------

# Don't check for existing files when making the following targets.
.PHONY: all clean libs run

# Default target.
all: $(BINDIR)/$(TARGET) content libs

clean:
	rm -rf $(CONTENTFILE) $(BINDIR) $(OBJDIR)

libs:
	mkdir -p $(BINDIR)
	cp -nr $(MONOGAME)/* $(BINDIR)

run: all
	cd $(BINDIR); \
	mono $(TARGET)

#-------------------
# MONO
#-------------------

# Always recompile. Makes it easier to work on the project.
.PHONY: $(BINDIR)/$(TARGET)

$(BINDIR)/$(TARGET):
	mkdir -p $(BINDIR)
	$(COMPILER) $(FLAGS)		      \
	            $(LIBPATHS)		      \
	            $(addprefix -r:, $(LIBS)) \
	            -out:$(BINDIR)/$(TARGET)  \
	            -recurse:$(SRCDIR)/*.cs

#-------------------
# MONOGAME
#-------------------

# Kind of a hack to build content easily.
.PHONY: Content/* pre-content content

Content/*.fbx:
	@echo /build:$@ >> $(CONTENTFILE)

Content/*.png:
	@echo /build:$@ >> $(CONTENTFILE)

pre-content:
	@echo /compress                   > $(CONTENTFILE)
	@echo /intermediateDir:$(OBJDIR) >> $(CONTENTFILE)
	@echo /outputDir:$(BINDIR)       >> $(CONTENTFILE)
	@echo /quiet                     >> $(CONTENTFILE)

content: pre-content $(CONTENT)
	mkdir -p $(BINDIR)
	mgcb -@:$(CONTENTFILE)
	rm -f $(CONTENTFILE)
