# from multiprocessing import Process

# def func1():
#   print 'func1: starting'
#   for i in xrange(10000000): pass
#   print 'func1: finishing'

# def func2():
#   print 'func2: starting'
#   for i in xrange(10000000): pass
#   print 'func2: finishing'

# if __name__ == '__main__':
#   p1 = Process(target=func1)
#   p1.start()
#   p2 = Process(target=func2)
#   p2.start()
#   p1.join()
#   p2.join()
from multiprocessing import Process
import sys
from multiprocessing import Pool
rocket = 0

def func1(links):
    global rocket
    print ('start func1')
    while rocket < 10000:
        rocket += 1
    for item in links:
        print(item)
    print ('end func1')
    

def func2(links):
    global rocket
    print ('start func2')
    while rocket < 10000:
        rocket += 1
    for item in links:
        print(item)
    print ('end func2')

if __name__=='__main__':
    p1 = Process(target=func1,args=[['One','Three']])
    #p1.start()
    p2 = Process(target=func1,args=[['Two','Four']])
    p1.start()
    p2.start()

    p1.join()
    p2.join()
labels=["Job_ID",
"Num_of_Positions",
"Business_Title",
"Title_Code_No",
"Level",
"Civil_Service_Title",
"Title_Classification",
"Job_Category",
"Proposed_Salary_Range",
"Career_Level",
"Work_Location",
"Division_Work_Unit",
"Posted",
"Post_Until"]
from multiprocessing import Pool
import time 


numOne=0
def f(x):
    print("Running for "+str(x))
    global numOne
    numOne += 1
    time.sleep(1)
    milk=[]
    milk.append(x)
    for i in range(0,5):
        milk.append(i)

    return x,numOne,milk

# if __name__ == '__main__':
#     val=[]
#     milk=[]
#     with Pool(5) as p:
#         val=p.map(f, labels,4)
        
#         print(val)

#     for item in val:
#         print(item)
    
#     print("DONE")

import multiprocessing
from itertools import product

def merge_names(a,b):
    return '{} & {}'.format(a[0], b)

if __name__ == '__main__':
    names = [['Brown', 'Wilson'], ['Bartlett', 'Rivera'], ['Molloy', 'Opie']]
    with multiprocessing.Pool(processes=3) as pool:
        results = pool.starmap(merge_names, names,2)
    print(results)