#********************************************************************************************************************
#Name		: BPGenerator.Py
#Author Name	: Saurav Gupta
#Date Created	: 04/10/2012
#Feature	: This file generates the BP of all the files in the specified directories and sub-directories.
#		  It captures File Size, File permissions, and MD5Checksum
#********************************************************************************************************************


import fnmatch
import os
import sys
import hashlib
import codecs
import csv

if len(sys.argv)==3:
    rootPath = sys.argv[1]
    pattern = '*.*'
    csvFilePath = sys.argv[2]

    # Initialize CSV
    #csvFilePath = os.path.join(basedir, '{0}.csv'.format(resultFileName))
    csvHeaderItems = [u'File Path', u'File size', u'File Permissions', u'File MD5Checksum']
    csvfilehandle = codecs.open(csvFilePath, encoding='utf-8', mode='w+')
    csvObj = csv.writer(csvfilehandle)
    csvObj.writerow(csvHeaderItems)

    print "BP Generation Started...",

    allPermissions = {u'R':os.R_OK, u'W':os.W_OK, u'X':os.X_OK, u'F':os.F_OK}
     
    for root, dirs, files in os.walk(rootPath):
        #for filename in fnmatch.filter(files, pattern):
        for filename in files:
            filePath = os.path.join(root, filename)

            # FilePath
            fileDetails = []
            fileDetails.append(u'%r'%filePath)

            # File Size
            try:
                fileDetails.append(os.path.getsize(filePath))
            except:
                fileDetails.append('0')
                
            # Permission on the file
            permissionStr = u''
            for key in allPermissions.keys():
                if os.access(filePath,allPermissions[key]):
                    permissionStr += key
            fileDetails.append(permissionStr)
                 
            # Md5 of the file
            md5 = hashlib.md5()
            try:
                file = open(filePath, 'rb')
                while True:
                    data = file.read(8096)
                    if not data:
                        break
                    md5.update(data)                
                file.close()
                md5CheckSum = md5.hexdigest()
            except:
                md5CheckSum = u'Failed to calculate MD5 Checksum'

            print("."),
            fileDetails.append(md5CheckSum)
            csvObj.writerow(fileDetails)

    print(".")
    print "Generation Completed."
else:
    print "Provide only two arguments: 1) Folder Path 2) Output CSV File Path"
