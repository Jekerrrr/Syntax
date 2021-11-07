from tkinter import *
from tkinter import filedialog
import TKlighter
import keyword
import os
root = Tk()
root.title('Syntax | Version 0.1')
root.geometry("1200x660")
def rgb_color(rgb):
    return "#%02x%02x%02x" % rgb
root.configure(bg=rgb_color((40, 40, 40)))
global open_status_name
open_status_name = False
#what u think this does lol
my_frame = Frame(root)
my_frame.pack(pady=5)

#scroll bar
text_scroll = Scrollbar(my_frame)
text_scroll_h = Scrollbar(my_frame, orient='horizontal')
text_scroll.pack(side=RIGHT, fill=Y)
text_scroll_h.pack(side=BOTTOM, fill=X)

#text box
my_text = Text(my_frame, width=19000, height=190000, font=("Fixedsys", 24), undo=True, wrap=NONE, yscrollcommand=text_scroll.set, xscrollcommand=text_scroll_h.set, bg=rgb_color((40, 40, 40)), fg=rgb_color((255, 255, 255)), insertbackground='white')
my_text.pack()

#scrollbar config
text_scroll.config(command=my_text.yview)
text_scroll_h.config(command=my_text.xview)

#Main menu
my_menu= Menu(root)
root.config(menu=my_menu)
#create new file
def new_file():
    my_text.delete("1.0", END)
    #Update status bar
    root.title('New File - Syntax')
    global open_status_name
    open_status_name = False
def open_file():
    root.title()
    #get file name
    text_file = filedialog.askopenfilename(initialdir="C:/Users/DefaultUser/Desktop", title="Open File", filetype=(("Text Files", "*.txt"), ("Python Files", "*.py"), ("C Files", "*.c"), ("JSON Files", "*.json"), ("Lua Files", "*.lua")))
    name = os.path.basename(text_file)
    if text_file:
    	global open_status_name
    	my_text.delete("1.0", END)
    	open_status_name = text_file
    	root.title(f'{name} | Syntax')
    #open file
    if text_file:
        text_file = open(text_file, 'r')
        content = text_file.read()
        #add the file to text box
        my_text.insert(END, content)
        text_file.close()
        highlight(Event)
def save_as():
    #get file name
    text_file = filedialog.asksaveasfilename(defaultextension=".*", initialdir="C:/Users/DefaultUser/Desktop", title="Save File", filetypes=(("Text Files", "*.txt"), ("Python Files", "*py"), ("C Files", "*.c"), ("Other", "*.")))
    if text_file:
        name = text_file
        root.title(f'{name} | Syntax')
    #Save the file
    text_file = open(text_file, 'w')
    text_file.write(my_text.get(1.0, END))
    text_file.close()
def save():
    global open_status_name
    if open_status_name:
        text_file = open(open_status_name, 'w')
        text_file.write(my_text.get(1.0, END))
        text_file.close()
    else:
        save_as()
def highlight(event):
    #Keywords
    TKlighter.def_h(my_text, rgb_color((3, 94, 252)))
    TKlighter.import_h(my_text, rgb_color((3, 94, 252)))
    TKlighter.from_h(my_text, rgb_color((3, 94, 252)))
    TKlighter.print_h(my_text, rgb_color((252, 3, 3)))
    TKlighter.if_h(my_text, rgb_color((252, 3, 3)))
    TKlighter.global_h(my_text, rgb_color((3, 94, 252)))
    TKlighter.while_h(my_text, rgb_color((252, 3, 3)))
    TKlighter.elif_h(my_text, rgb_color((252, 3, 3)))
    TKlighter.else_h(my_text, rgb_color((252, 3, 3)))	
    #numbers
    TKlighter.zero_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.one_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.two_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.three_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.four_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.five_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.six_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.seven_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.eight_h(my_text, rgb_color((173, 255, 161)))
    TKlighter.nine_h(my_text, rgb_color((173, 255, 161)))
    #True/False
    TKlighter.True_h(my_text, rgb_color((3, 94, 252)))
    TKlighter.False_h(my_text, rgb_color((3, 94, 252)))
    #Strings
    TKlighter.custom_regex_h(my_text, r'"\w+"', rgb_color((255, 251, 0)))
    TKlighter.custom_regex_h(my_text, r"'\w+'", rgb_color((255, 251, 0)))
    TKlighter.custom_regex_h(my_text, r'#\w+', rgb_color((255, 94, 0)))


my_text.bind('<Key>', highlight)
#File menu
file_menu = Menu(my_menu, tearoff=False)
my_menu.add_cascade(label="File", menu=file_menu)
file_menu.add_command(label="New", command=new_file)
file_menu.add_separator()
file_menu.add_command(label="Open", command=open_file)
file_menu.add_separator()
file_menu.add_command(label="Save", command=save)
file_menu.add_separator()
file_menu.add_command(label="Save As", command=save_as)


#edit menu
edit_menu = Menu(my_menu, tearoff=False)
my_menu.add_cascade(label="Edit", menu=edit_menu)
edit_menu.add_command(label="Cut")
edit_menu.add_separator()
edit_menu.add_command(label="Copy")
edit_menu.add_separator()
edit_menu.add_command(label="Undo")
edit_menu.add_separator()
edit_menu.add_command(label="Re-Do")
highlight(Event)
root.mainloop()
