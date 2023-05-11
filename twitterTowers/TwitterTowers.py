from enum import Enum
import math
#class Tower(Enum):
 #   triangle = 1
  #  square = 2
   # exit = 3

def main():
        flag=True
        while flag:
            try:
                option=int(input("coose option 1 or 2, to exit choose 3\n"))
            except ValueError:
                print("ERROR: Input number is incorrect!\n")
            if option < 1 or option>3:
                raise Exception("you must choose option between 1 to 3\n")
            match option:
                case 1:
                    try:
                        height=int(input("insert height\n"))
                        width=int(input("insert width\n"))
                    except ValueError:
                        raise Exception("ERROR: Input number is incorrect!\n")
                    if height==width or abs(height-width)>5:
                        print("The rectangle area is: ",height*width)
                    else:
                        print("The rectangle scope is: ",2*height+2*width)
                    
                case 2:
                    try:
                        height=int(input("insert height\n"))
                        width=int(input("insert width\n"))
                    except ValueError:
                        raise Exception("ERROR: Input number is incorrect!\n")
                    try:
                        option2=int(input("coose option 1 or 2\n"))
                    except ValueError:
                        print("ERROR: Input number is incorrect!\n")
                    if option2 < 1 or option2>2:
                            raise Exception("you must choose option between 1 to 2\n")
                    match option2:
                        case 1:
                            print("The triangle scope is: ",TriangleScope(height,width))
                        case 2:
                            if width%2==0 or width>height*2:
                                print("Triagle can't be printed\n")
                            else:
                                printTriangle(height, width)
                    
                case 3:
                    flag=False


def printTriangle(height, width):
    blank=int(width//2)-1
    print(blank*' ','*')
    blank=blank-1
    k=int((height-2)//((width-2)//2)) #the lines between
    leftover=int(height-2-k*((width-2)//2))#the leftover
    for p in range(leftover):
        print(blank*' ','***')
    for i in range(3,int(width-1),2):
        for j in range(k):
            print(blank*' ','*'*i)
        blank=blank-1   
    print('*'*int(width))


                    
def TriangleScope(height,width):
    half=width/2
    side=math.sqrt(height*height+half*half)
    return round(side*2+width,2)

                              




if __name__=='__main__':
    main()