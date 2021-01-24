import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ListService {
  async createList(newListData) {
    try {
      const res = await api.post('/api/list', newListData)
      logger.log(res.data)
    } catch (error) {
      logger.logger(error)
    }
  }

  async deleteList(listId) {
    try {
      const res = await api.delete('/api/list/' + listId)
      logger.log(res.data)
    } catch (error) {
      logger.log(error)
    }
  }
}

export const listService = new ListService()
