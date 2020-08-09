from flask import Flask, render_template, request, redirect

import os
import sys
import json
import mysql.connector
from dbconn import dbconfig
app = Flask(__name__)


# Database configuration dictionary
# Database configuration dictionary

@app.route('/')
@app.route("/index")
def index():
    print("Connection made")
    mydb = mysql.connector.connect(
    host=dbconfig['host'],
    port=dbconfig['port'],
    user=dbconfig['user'],
    passwd=dbconfig['passwd'],
    database="nyc_gov_jobs")
    mycursor=mydb.cursor()


    mycursor.execute("select COUNT(*) from search_by_agencycode")
    myresult = mycursor.fetchall()

    get_options="SELECT LongCategory from search_by_agencycode GROUP BY LongCategory ORDER BY LongCategory"

    mycursor.execute(get_options)
    get_options=mycursor.fetchall()
    return render_template('index.html',num_items=myresult[0][0],agencylist=get_options)

@app.route('/read',methods=['GET', 'POST'])
def reader():

    if request.method == "GET":
        req = request.args

        mydb = mysql.connector.connect(
        host=dbconfig['host'],
        port=dbconfig['port'],
        user=dbconfig['user'],
        passwd=dbconfig['passwd'],
        database="nyc_gov_jobs")
        mycursor=mydb.cursor()


        sql = """SELECT * FROM `search_by_agencycode`
        WHERE `Title` Like %s AND
        `jobNum` Like %s AND
        `shortCategory` Like %s AND
        `LongCategory` Like %s
        ORDER BY `Title`;"""
        #sql=sql.format(title=req['title'],jobNum=req['jobnum'],shortcat=req['shortagency'],longcat=req['longagency'])
        params=(req['title']+'%',req['jobnum']+'%',req['shortagency']+'%',req['longagency']+'%')
        mycursor.execute(sql,params)
        results=mycursor.fetchall()
        num_items=len(results)
        print(num_items)
        return render_template('read.html',data=results,num_item=num_items)

    return render_template('index.html')

