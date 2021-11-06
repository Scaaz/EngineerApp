<template>
  <div class="container">
    <div class="large-12 medium-12 small-12 cell">
      <label
        >File
        <input type="file" id="file" ref="myFiles" @change="handleFileUpload()" />
      </label>
      <button @click="submitFile()">Submit</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Home",
  data() {
    return {
      file: "",
    };
  },

  methods: {
    handleFileUpload() {
      console.log('start handle')
       this.file = this.$refs.myFiles.files
      console.log(this.file)
      console.log('end handle')
    },

    submitFile() {
      let formData = new FormData();

      formData.append("file", this.file);

      axios
        .post("api/UploadFile", formData, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then(function() {
          console.log("SUCCESS!!");
        })
        .catch(function() {
          console.log("FAILURE!!");
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
