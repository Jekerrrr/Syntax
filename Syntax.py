from tkinter import *
from tkinter import filedialog
import stlighting
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
my_text = Text(my_frame, width=19000, height=190000, font=("Courier New", 14), undo=True, wrap=NONE, yscrollcommand=text_scroll.set, xscrollcommand=text_scroll_h.set, bg=rgb_color((40, 40, 40)), fg=rgb_color((255, 255, 255)), insertbackground='white')
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
    root.title("New File - Syntax")
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
    text_file = filedialog.asksaveasfilename(defaultextension=".*", initialdir="C:/Users/DefaultUser/Desktop", title="Save File", filetypes=(("Other", "*."), ("Python Files", "*py"), ("C Files", "*.c"), ("Text file", "*.txt")))
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
    stlighting.def_h(my_text, rgb_color((97, 158, 255)))
    stlighting.import_h(my_text, rgb_color((3, 94, 252)))
    stlighting.from_h(my_text, rgb_color((3, 94, 252)))
    stlighting.print_h(my_text, rgb_color((252, 3, 3)))
    stlighting.if_h(my_text, rgb_color((252, 3, 3)))
    stlighting.global_h(my_text, rgb_color((3, 94, 252)))
    stlighting.while_h(my_text, rgb_color((252, 3, 3)))
    stlighting.elif_h(my_text, rgb_color((252, 3, 3)))
    stlighting.else_h(my_text, rgb_color((252, 3, 3)))
    stlighting.for_h(my_text, rgb_color((252, 3, 3)))
    stlighting.in_h(my_text, rgb_color((252, 3, 3)))
    stlighting.open_h(my_text, rgb_color((252, 3, 3)))	
    #numbers
    stlighting.zero_h(my_text, rgb_color((255, 251, 0)))
    stlighting.one_h(my_text, rgb_color((255, 251, 0)))
    stlighting.two_h(my_text, rgb_color((255, 251, 0)))
    stlighting.three_h(my_text, rgb_color((255, 251, 0)))
    stlighting.four_h(my_text, rgb_color((255, 251, 0)))
    stlighting.five_h(my_text, rgb_color((255, 251, 0)))
    stlighting.six_h(my_text, rgb_color((255, 251, 0)))
    stlighting.seven_h(my_text, rgb_color((255, 251, 0)))
    stlighting.eight_h(my_text, rgb_color((255, 251, 0)))
    stlighting.nine_h(my_text, rgb_color((255, 251, 0)))
    #True/False
    stlighting.True_h(my_text, rgb_color((97, 158, 255)))
    stlighting.False_h(my_text, rgb_color((97, 158, 255)))
    #methods
    stlighting.custom_regex_h(my_text, "range", rgb_color((3, 94, 252)))
    #Strings
    stlighting.single_qouts_h(my_text, rgb_color((255, 251, 0)))
    stlighting.double_qouts_h(my_text, rgb_color((255, 251, 0)))

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
