using System;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace AmazonS3Demo
{
    public class AmazonS3Uploader
    {
        private string bucketName = "teststoragemanager542020";
        private string keyName = "fileKeyName";
        private string filePath = "C:\\Users\\543232\\Desktop\\t3upload.txt";

        public void UploadFile()
        {
            var client = new AmazonS3Client("AKIAIE2V63W4AYEBTQPQ", "", Amazon.RegionEndpoint.USEast2);

            try
            {
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    FilePath = filePath,
                    ContentType = "text/plain"
                };

                PutObjectResponse response = client.PutObject(putRequest);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}