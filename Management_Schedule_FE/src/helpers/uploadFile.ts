const url = `https://api.cloudinary.com/v1_1/djht2mddc/auto/upload`

const uploadFile = async(file:File)=>{
    const formData = new FormData()
    formData.append('file',file)
    formData.append("upload_preset","chat-app-file")

    const response = await fetch(url,{
        method : 'post',
        body : formData
    })
    const responseData = await response.json()


    return responseData
}

export default uploadFile