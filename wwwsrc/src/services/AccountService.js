import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/profile')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getLists() {
    try {
      const res = await api.get('/api/list')
      logger.log(res.data)
    } catch (error) {
      logger.log(error)
    }
  }
}

export const accountService = new AccountService()
