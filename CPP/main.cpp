#include <Windows.h>
#include <fstream>
#include <iostream>
#include <string>
#include <vector>
#include <shlobj.h>
#include <atlstr.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <direct.h>

#pragma comment(lib, "shell32.lib")

//###########################################################
//#To Do: Does save every click, but should only every 20...#
//###########################################################


void checkMouseButtonStatus(long *clicks_left, long*clicks_right, bool* pressed_left, bool *pressed_right, short *counter, std::string documents_path) {
	//Check if mouse left button is pressed or not
	if ((GetKeyState(VK_LBUTTON) & 0x80) != 0 && *pressed_left == false) {  //It's pressed
		*clicks_left = *clicks_left + 1;
		*counter = *counter + 1;
		*pressed_left = true;
	}

	//Check if mouse right button is pressed or not
	if((GetKeyState(VK_RBUTTON) & 0x80) != 0 && *pressed_right == false){
		*clicks_right = *clicks_right + 1;
		*counter = *counter + 1;
		*pressed_right = true;
	}

	//Not pressed
	if ((GetKeyState(VK_RBUTTON) & 0x80) == 0) {
		*pressed_right = false;
	}

	if ((GetKeyState(VK_LBUTTON) & 0x80) == 0) {
		*pressed_left = false;
	}
	
	//Save all 20 Clicks, to get better performance...
	if (*counter >= 20) {
		std::ofstream myfile;
		myfile.open(documents_path + "\\ClickCounter\\click_stats.txt");
		myfile << *clicks_right << std::endl;
		myfile << *clicks_left << std::endl;
		myfile.close();
		*counter = 0;
	}
}

int main() {

	//Hide consolewindow
	ShowWindow(GetConsoleWindow(), SW_HIDE);

	long clicks_left = 0;
	long clicks_right = 0;
	
	bool pressed_right = false;
	bool pressed_left = false;

	short counter = 0;

	//Get Documents path
	std::string documents_path;
	PWSTR my_documents;
	HRESULT result = SHGetKnownFolderPath(FOLDERID_Documents, KF_FLAG_SIMPLE_IDLIST, NULL, &my_documents);
	documents_path = CW2A(my_documents);

	//Check if Folder "ClickCounter" exists in Documents
	struct stat info;
	if (stat((documents_path + "\\ClickCounter").c_str(), &info) != 0) {
		//Doesn't exist
		//Create new folder
		_mkdir((documents_path + "\\ClickCounter").c_str());
	}

	std::ifstream f_in(documents_path + "\\ClickCounter\\click_stats.txt");
	if (f_in) {
		std::string line;
		std::string arr[2];
		//file exists
		int i = 0;
		while (f_in >> line) {
			if (i == 0) {
				clicks_right = stoi(line);
			}
			if(i == 1) {
				clicks_left = stoi(line);
			}
			std::cout << i << std::endl;
			i++;
		}
		std::cout << "Right: " << clicks_right << std::endl << "Left: " << clicks_left << std::endl;
		f_in.close();
	}

	while(true){
		Sleep(10);
		checkMouseButtonStatus(&clicks_left, &clicks_right, &pressed_left, &pressed_right, &counter, documents_path);
	}
	return 0;
}