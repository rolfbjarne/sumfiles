sumfiles.exe: $(wildcard *.cs) sumfiles.csproj
	@xbuild /nologo /verbosity:quiet

install: sumfiles.exe
	@cat sf | sed 's#%ORIGIN%#$(CURDIR)#' > ~/bin/sf
	@chmod +x ~/bin/sf
	@echo Installed ~/bin/sf

all: sumfiles.exe
