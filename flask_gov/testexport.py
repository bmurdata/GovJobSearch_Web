import os
import mysql.connector
from dbconn import dbconfig

mydb=mysql.connector.connect(host=dbconfig['host']
,port=dbconfig['port']
,user= dbconfig['user']
,passwd=dbconfig['passwd']
,database=dbconfig['database'])

mycursor=mydb.cursor()

print(os.getcwd())
mycursor.execute("select COUNT(*) from search_by_agencycode")
myresult = mycursor.fetchall()
print(myresult)
print(mycursor.callproc( 'mixer'))

