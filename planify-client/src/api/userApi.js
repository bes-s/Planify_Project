import axiosClient from './axiosClient';

const userApi = {
  getAll: () => axiosClient.get('/users'),
  create: (userData) => axiosClient.post('/users', userData),

};

export default userApi;
