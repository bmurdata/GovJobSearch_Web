from flask import Flask, render_template, request, redirect

import os
import sys
import json
import mysql.connector

app = Flask(__name__)

mydb = mysql.connector.connect(
    host="",
    port="",
    user="",
    passwd="",
    database="nyc_gov_jobs"
)

mycursor = mydb.cursor()

# mycursor.execute("SHOW TABLES")
mycursor.execute("select COUNT(*) from search_by_agencycode")
myresult = mycursor.fetchall()
print(myresult)
@app.route('/')
@app.route("/index")
def index():
    mycursor.execute("select COUNT(*) from search_by_agencycode")
    myresult = mycursor.fetchall()

    get_options="SELECT LongCategory from search_by_agencycode GROUP BY LongCategory"

    mycursor.execute(get_options)
    get_options=mycursor.fetchall()
    print(get_options)
    return render_template('index.html',num_items=myresult[0][0],agencylist=get_options)

@app.route('/read',methods=['GET', 'POST'])
def reader():

    if request.method == "GET":
        req = request.args

        mycursor = mydb.cursor()

        sql = '''SELECT * FROM `search_by_agencycode` 
        WHERE `Title` Like "{title}%" AND 
        `jobNum` Like "{jobNum}%" AND 
        `shortCategory` Like '{shortcat}%' AND
        `LongCategory` Like '{longcat}%'
        ORDER BY `Title`;'''
        
        print(sql)
        sql=sql.format(title=req['title'],jobNum=req['jobnum'],shortcat=req['shortagency'],longcat=req['longagency'])
        print(sql)
        mycursor.execute(sql)
        results=mycursor.fetchall()
        num_items=len(results)
        print(num_items)
        return render_template('read.html',data=results,num_item=num_items)

    return render_template('index.html')

